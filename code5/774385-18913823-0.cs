    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using FluentAssertions;
    using Ninject;
    using Ninject.Activation;
    using Ninject.Parameters;
    using Ninject.Syntax;
    using Xunit;
    public class NinjectFactoryTest
    {
        [Fact]
        public void Test()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IUnitOfMeasurementFactory>().To<UnitOfMeasurementFactory>();
            kernel.Bind<UnitOfMeasurement>().To<Knots>()
                .WhenClassifiedBy(VelocityUnitOfMeasurementFactory.BuildClassification(VelocityTypes.Knots));
            kernel.Bind<UnitOfMeasurement>().To<Meters>()
                .WhenClassifiedBy(DistanceUnitOfMeasurementFactory.BuildClassification(DistanceTypes.Meters));
            const string ExpectedName = "hello";
            const double ExpectedValue = 5.5;
            var actualUnitOfMeasurement = kernel.Get<VelocityUnitOfMeasurementFactory>()
                .CreateVelocityUnitOfMeasurement(VelocityTypes.Knots, ExpectedName, ExpectedValue);
            actualUnitOfMeasurement.Should().BeOfType<Knots>();
            actualUnitOfMeasurement.Name.Should().Be(ExpectedName);
            actualUnitOfMeasurement.Value.Should().Be(ExpectedValue);
        }
    }
    public class ClassifiedParameter : Parameter
    {
        public ClassifiedParameter(string classification)
            : base("Classification", ctx => null, false)
        {
            this.Classification = classification;
        }
        public string Classification { get; set; }
    }
    public static class ClassifiedBindingExtensions
    {
        public static IBindingInNamedWithOrOnSyntax<T> WhenClassifiedBy<T>(this IBindingWhenSyntax<T> syntax, string classification)
        {
            return syntax.When(request => request.IsValidForClassification(classification));
        }
        public static bool IsValidForClassification(this IRequest request, string classification)
        {
            ClassifiedParameter parameter = request
                .Parameters
                .OfType<ClassifiedParameter>()
                .SingleOrDefault();
            return parameter != null && classification == parameter.Classification;
        }
    }
    public enum MeasurementTypes
    {
        Position,
        Distance,
        Altitude,
        Velocity,
        Clock
    }
    public enum VelocityTypes
    {
        [Description("meters / second")]
        MetersPerSecond,
        [Description("knots")]
        Knots
    }
    public enum DistanceTypes
    {
        Meters,
        NauticalMiles,
        StatuteMiles
    }
    public interface IUnitOfMeasurementFactory
    {
        UnitOfMeasurement Create(string classification, string name, double value);
    }
    internal class UnitOfMeasurementFactory : IUnitOfMeasurementFactory
    {
        public const string ClassificationTemplate = "{0}://{1}";
        private readonly IResolutionRoot resolutionRoot;
        public UnitOfMeasurementFactory(IResolutionRoot resolutionRoot)
        {
            this.resolutionRoot = resolutionRoot;
        }
        public UnitOfMeasurement Create(string classification, string name, double value)
        {
            return this.resolutionRoot.Get<UnitOfMeasurement>(
                new ClassifiedParameter(classification),
                new ConstructorArgument("name", name),
                new ConstructorArgument("value", value));
        }
    }
    public class DistanceUnitOfMeasurementFactory
    {
        private readonly IUnitOfMeasurementFactory factory;
        public DistanceUnitOfMeasurementFactory(IUnitOfMeasurementFactory factory)
        {
            this.factory = factory;
        }
        public static string BuildClassification(DistanceTypes distanceType)
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                UnitOfMeasurementFactory.ClassificationTemplate,
                MeasurementTypes.Distance.ToString(),
                distanceType.ToString());
        }
        public UnitOfMeasurement CreateDistanceUnitOfMeasurement(DistanceTypes distanceType, string name, double value)
        {
            string classification = BuildClassification(distanceType);
            return this.factory.Create(classification, name, value);
        }
    }
    public class VelocityUnitOfMeasurementFactory
    {
        private readonly IUnitOfMeasurementFactory factory;
        public VelocityUnitOfMeasurementFactory(IUnitOfMeasurementFactory factory)
        {
            this.factory = factory;
        }
        public static string BuildClassification(VelocityTypes velocityType)
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                UnitOfMeasurementFactory.ClassificationTemplate,
                MeasurementTypes.Velocity.ToString(),
                velocityType.ToString());
        }
        public UnitOfMeasurement CreateVelocityUnitOfMeasurement(VelocityTypes velocityType, string name, double value)
        {
            string classification = BuildClassification(velocityType);
            return this.factory.Create(classification, name, value);
        }
    }
    public abstract class UnitOfMeasurement
    {
        public MeasurementTypes MeasurementType { get; set; }
        public int RoundingDigits { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public string Units { get; set; }
    }
    public sealed class Knots : UnitOfMeasurement
    {
        public Knots(string name, double value)
        {
            MeasurementType = MeasurementTypes.Velocity;
            RoundingDigits = 5;
            Name = name;
            Value = value;
            Units = "knots";
        }
    }
    public sealed class Meters : UnitOfMeasurement
    {
        public Meters(string name, double value)
        {
            MeasurementType = MeasurementTypes.Distance;
            RoundingDigits = 5;
            Name = name;
            Value = value;
            Units = "m";
        }
    }

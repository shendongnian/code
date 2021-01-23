    using NSubstitute; // see http://nsubstitute.github.io/
    using NUF = NUnit.Framework;
    [NUF.TestFixture]
    public class LogFactoryTest {
       [NUF.Test]public void CreateNew_should_call_now() {
          var clock = Substitute.For<IClock>();
          var fac = new LogFactory(clock);
          fac.CreateNew("a", "b", "c");
          clock.Received().Now();
       }
       [NUF.Test]public void CreateNew_should_set_correct_value() {
          var clock = Substitute.For<IClock>();
          var now = new System.DateTime(2014, 1, 15, 18, 0, 0);
          clock.Now().Returns(now);
          var fac = new LogFactory(clock);
          LogItem log = fac.CreateNew("a", "b", "c");
    
          NUF.Assert.That(log.OccurredOn, NUF.Is.EqualTo(now));
       }
    }

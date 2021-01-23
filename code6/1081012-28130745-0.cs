    public interface ISecretFactory<T>
    {
        T Create(string param);
    }
    public abstract class Base<T> where T : Base<T>, ISecretFactory<T>
    {
        public T GetChild()
        {
            // We are sure type T always implements ISecretFactory<T>
            var factory = this as ISecretFactory<T>;
            return factory.Create("base param");
        }
    }
    public class Derivative : Base<Derivative>, ISecretFactory<Derivative>
    {
        public Derivative()
        {
        }
        private Derivative(string param)
        {
        }
        Derivative ISecretFactory<Derivative>.Create(string param)
        {
            return new Derivative(param);
        }
    }
    public class SecondDerivative : Derivative
    {
        public void F()
        {
            // intellisense won't show Create method here.
            // But 'this as ISecretFactory<Derivative>' trick still works.
        }
    }

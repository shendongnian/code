    public abstract class InterpolatedText
    {
        public abstract string GreetingWithName(string firstName, string lastName);
    }
    public class InterpolatedTextEnglish : InterpolatedText
    {
        public override string GreetingWithName(string firstName, string lastName) =>
            $"Hello, my name is {firstName} {lastName}.";
    }

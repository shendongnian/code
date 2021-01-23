    public class MyClass
    {
        [ContentObfuscation(Exclude = true)]
        public MyClass()
        {
            // SecurityCriticalClass is obfuscated
            var securityCriticalClass = new SecurityCriticalClass();
            securityCriticalClass.DoSomeTopSecretStuff();
        }
    }

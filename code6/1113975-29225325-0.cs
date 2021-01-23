    [Cmdlet("Get", "LivingCharacter")]
    public class GetLivingCharacter : Cmdlet, IDynamicParameters
    {
        protected override void ProcessRecord()
        {
        }
        public object GetDynamicParameters()
        {
            WriteDebug("Getting names"); // Tab completion won't work with this here - comment it out and it works.
            ^^^^^^^^^^
            var chars = new List<String>() { "Bran", "Arya" };            
            var dict = new RuntimeDefinedParameterDictionary();
            var attributes = new Collection<Attribute>
            {
                new ParameterAttribute
                {
                    HelpMessage = "Enter a valid open name",
                    Mandatory = true
                },
                new ValidateSetAttribute(chars.ToArray()),
            };
            dict.Add("Name", new RuntimeDefinedParameter("Name", typeof(string), attributes));
            return dict;
        }
    }

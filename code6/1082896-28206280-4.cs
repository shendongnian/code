    The problem here is that, as you suspect, there is no property corresponding to `members`.  What your JSON has is an array of objects, each of which might have an array-valued property `Family`.  Thus your data model should look like:
        public class ResponseItem
        {
            public int? OptionChoice { get; set; }
            public string OptionText { get; set; }
            public List<FamilyMember> Family { get; set; }
            // Other fields not shown from {...}
        }
        public class FamilyMember
        {
            public string FName { get; set; }
            public string LName { get; set; }
            public string DOB { get; set; }
            public string Gender { get; set; }
            public string Type { get; set; }
        }

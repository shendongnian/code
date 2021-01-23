    public class ParentThingDTO
    {
        public ParentThingDTO(ParentViewModel model)
        {
            FirstThingCode = model.FirstThingCode;
            FirstThingName = model.FirstThingName;
            SecondThingCode = model.SecondThingCode;
            SecondThingName = model.SecondThingName;
        }
        public int Id { get; set; }
        public string FirstThingCode { get; set; }
        public string FirstThingName { get; set; }
        public string SecondThingCode { get; set; }
        public string SecondThingName { get; set; }
        public ParentThing GenerateEntity()
        {
            var thing = new ParentThing();
            thing.TheFirstThing = new ChildThing
            {
                Code = FirstThingCode,
                Name = FirstThingName
            };
            if (!string.IsNullOrWhiteSpace(SecondThingCode))
            {
                thing.TheSecondThing = new ChildThing
                {
                    Code = SecondThingCode,
                    Name = SecondThingName
                };
            }
            return thing;
        }
    }

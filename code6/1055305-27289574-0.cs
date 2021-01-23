    class AbstractPerson
    {
        AbstractAttribute Attribute { get; set; }
    }
    class Pilot : AbstractPerson
    {
        PilotAttribute PilotAttribute
        {
            get { return (PilotAttribute)AbstractAttribute; }
            set { AbstractAttribute = value; }
        }
    }

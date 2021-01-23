    public class ParentClass<TSettings>
        where TSettings : MainSettingsClass
    {
        protected TSettings settings;
        public ParentClass(TSettings settings)
        {
            this.settings = settings;
        }
    }
    public class ChildClass_1 : ParentClass<SubSettingsClass_1>
    {
        ...
    }
    public class ChildClass_2 : ParentClass<SubSettingsClass_2>
    {
        ...
    }

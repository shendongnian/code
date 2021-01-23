    public static ControlType IdentifyControlByIdentifierEqualsValue<ControlType>(UITestControl parent, ControlIdentifier identifierTypeAndValue) where ControlType : UITestControl
        {
            var control = (ControlType)Activator.CreateInstance(typeof(ControlType), new UITestControl[] { parent });
            control.SearchProperties.Add(identifierTypeAndValue.Type, identifierTypeAndValue.Value);
            var wasFound = control.TryFind();
            if (!wasFound)
                throw new UITestControlNotFoundException("The control of type " + control.GetType().ToString() + " with the identifier type of " + identifierTypeAndValue.Type + " and the identifying attribute of " + identifierTypeAndValue.Value + " was not able to be found");
            return control;
        }

    public abstract class WizardPage
    {
        // Replace or override existing constructor with this
        public WizardPage(int unknownInt, Type currentType, string str)
        {
            if (currentType == null)
                currentType = System.Reflection.MethodBase()
                                  .GetCurrentMethod().GetType();
            var localString = getLocalizedString(currentType, str);
            // Existing logic here
        }
    }

        private static void EnsureIsDependencyPropertyName(ref string dependencyPropertyName)
        {
            if (!dependencyPropertyName.EndsWith("Property"))
                dependencyPropertyName += "Property";
        }

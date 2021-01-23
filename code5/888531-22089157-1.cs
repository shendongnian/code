    public string UsingDirectives(bool inHeader, bool includeCollections = true)
    {
        return inHeader == string.IsNullOrEmpty(_code.VsNamespaceSuggestion())
            ? string.Format(
                CultureInfo.InvariantCulture,
                "{0}using System;{1}" +
                "{2}" +
				"{3}",
                inHeader ? Environment.NewLine : "",
                includeCollections ? (Environment.NewLine + "using System.Collections.Generic;") : "",
				includeCollections ? (Environment.NewLine + "using System.Runtime.Serialization;") : "",
				inHeader ? "" : Environment.NewLine)
            : "";
    }

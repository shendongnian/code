    using System;
    using System.Globalization;
    using Microsoft.Reporting.WebForms;
    
    namespace SomeApplication
    {
        public class DutchReportViewerMessages : IReportViewerMessages, IReportViewerMessages2, IReportViewerMessages3
        {
            #region IReportViewerMessages Members
    
            // English value: Back to Parent Report
            public string BackButtonToolTip
            {
                get { return "Terug naar het vorige rapport"; }
            }
    
            // English value: Change Credentials
            public string ChangeCredentialsText
            {
                get { return "Wijzig Rechten"; }
            }
    
            // English value: Change Credentials
            public string ChangeCredentialsToolTip
            {
                get { return "Wijzig Rechten"; }
            }
    
            // English value: Current Page
            public string CurrentPageTextBoxToolTip
            {
                get { return "Huidige Pagina"; }
            }
    
            // English value: Document Map
            public string DocumentMap
            {
                get { return "Document Map"; }
            }
    
            // English value: Show / Hide Document Map
            public string DocumentMapButtonToolTip
            {
                get { return "Toon / Verberg Document Map"; }
            }
    
            // English value: Export
            public string ExportButtonText
            {
                get { return "Exporteer"; }
            }
    
            // English value: Export
            public string ExportButtonToolTip
            {
                get { return "Exporteer"; }
            }
    
            // English value: Export Formats
            public string ExportFormatsToolTip
            {
                get { return "Exporteer Formaten"; }
            }
    
            // English value: False
            public string FalseValueText
            {
                get { return "Onwaar"; }
            }
    
            // English value: Find
            public string FindButtonText
            {
                get { return "Zoek"; }
            }
    
            // English value: Find
            public string FindButtonToolTip
            {
                get { return "Zoek"; }
            }
    
            // English value: Next
            public string FindNextButtonText
            {
                get { return "Volgende"; }
            }
    
            // English value: Find Next
            public string FindNextButtonToolTip
            {
                get { return "Volgend Resultaat"; }
            }
    
            // English value: First Page
            public string FirstPageButtonToolTip
            {
                get { return "Eerste Pagina"; }
            }
    
            // English value: Enter a valid page number
            public string InvalidPageNumber
            {
                get { return "Voer een geldig paginanummer in"; }
            }
    
            // English value: Last Page
            public string LastPageButtonToolTip
            {
                get { return "Laatste Pagina"; }
            }
    
            // English value: Next Page
            public string NextPageButtonToolTip
            {
                get { return "Volgende Pagina"; }
            }
    
            // English value: The entire report has been searched.
            public string NoMoreMatches
            {
                get { return "Het volledige rapport is doorzocht."; }
            }
    
            // English value: NULL
            public string NullCheckBoxText
            {
                get { return "Geen waarde"; }
            }
    
            // English value: Null
            public string NullValueText
            {
                get { return "Geen waarde"; }
            }
    
            // English value: of
            public string PageOf
            {
                get { return "van"; }
            }
    
            // English value: Show / Hide Parameters
            public string ParameterAreaButtonToolTip
            {
                get { return "Toon / Verberg Parameters"; }
            }
    
            // English value: Password:
            public string PasswordPrompt
            {
                get { return "Wachtwoord:"; }
            }
    
            // English value: Previous Page
            public string PreviousPageButtonToolTip
            {
                get { return "Vorige Pagina"; }
            }
    
            // English value: Print
            public string PrintButtonToolTip
            {
                get { return "Afdrukken"; }
            }
    
            // English value: Loading...
            public string ProgressText
            {
                get { return "Verwerken..."; }
            }
    
            // English value: Refresh
            public string RefreshButtonToolTip
            {
                get { return "Vernieuwen"; }
            }
    
            // English value: Find Text in Report
            public string SearchTextBoxToolTip
            {
                get { return "Zoek naar tekst binnen het rapport"; }
            }
    
            // English value: <Select a Value>
            public string SelectAValue
            {
                get { return "<Selecteer een waarde>"; }
            }
    
            // English value: (Select All)
            public string SelectAll
            {
                get { return "(Selecteer alles)"; }
            }
    
            // English value: Select a format
            public string SelectFormat
            {
                get { return "Selecteer een formaat"; }
            }
    
            // English value: The search text was not found.
            public string TextNotFound
            {
                get { return "De zoektekst is niet gevonden."; }
            }
    
            // English value: Today is {0}
            public string TodayIs
            {
                get { return "Vandaag is {0}"; }
            }
    
            // English value: True
            public string TrueValueText
            {
                get { return "Waar"; }
            }
    
            // English value: Log In Name:
            public string UserNamePrompt
            {
                get { return "Gebruikersnaam:"; }
            }
    
            // English value: View Report
            public string ViewReportButtonText
            {
                get { return "Toon Rapport"; }
            }
    
            // English value: Zoom
            public string ZoomControlToolTip
            {
                get { return "Zoom"; }
            }
    
            // English value: Page Width
            public string ZoomToPageWidth
            {
                get { return "Paginabreedte"; }
            }
    
            // English value: Whole Page
            public string ZoomToWholePage
            {
                get { return "Volledige pagina"; }
            }
    
            #endregion
    
            #region IReportViewerMessages2 Members
    
            // English value: Your browser does not support scripts or has been configured not to allow scripts.
            public string ClientNoScript
            {
                get { return "Uw browser ondersteunt geen JavaScript of deze ondersteuning is uitgeschakeld."; }
            }
    
            // English value: Unable to load client print control.
            public string ClientPrintControlLoadFailed
            {
                get { return "Het laden van het client print control is niet gelukt."; }
            }
    
            // English value: One or more data sources is missing a user name.
            public string CredentialMissingUserNameError(string dataSourcePrompt)
            {
                return "Een of meerdere databronnen missen een gebruikersnaam.";
            }
    
            // English value is different for each Rendering Extension. See comment behind each type.
            public string GetLocalizedNameForRenderingExtension(string format)
            {
                switch (format)
                {
                    case "XML"   : return "XML databestand (.xml)";  // XML file with report data
                    case "CSV"   : return "CSV databestand (.csv)";  // CSV (comma delimited)
                    case "PDF"   : return "PDF document (.pdf)";     // PDF
                    case "MHTML" : return "Webarchief (.mhtml)";     // MHTML (web archive)
                    case "EXCEL" : return "Excel rekenblad (.xls)";  // Excel
                    case "IMAGE" : return "Afbeelding (.tif)";       // TIFF file
                    case "WORD"  : return "Word document (.doc)";    // Word
                    default      : return null;
                }
            }
    
            // English value: Select a value
            public string ParameterDropDownToolTip
            {
                get { return "Selecteer een waarde"; }
            }
    
            // English value: Please select a value for the parameter '{0}'.
            public string ParameterMissingSelectionError(string parameterPrompt)
            {
                return String.Format(CultureInfo.CurrentCulture, "Selecteer een waarde voor de parameter '{0}'", parameterPrompt);
            }
    
            // English value: Please enter a value for the parameter '{0}'. The parameter cannot be blank.
            public string ParameterMissingValueError(string parameterPrompt)
            {
                return String.Format(CultureInfo.CurrentCulture, "Selecteer een waarde voor de parameter '{0}'. De parameter mag niet leeg zijn.", parameterPrompt);
            }
    
            #endregion
    
            #region IReportViewerMessages3 Members
    
            // English value: Loading...
            public string CalendarLoading
            {
                get { return "Verwerken..."; }
            }
    
            // English value: Cancel
            public string CancelLinkText
            {
                get { return "Annuleer"; }
            }
    
            // English value: pageCount if PageCountMode.Actual, else pageCount suffixed with a ?
            public string TotalPages(int pageCount, PageCountMode pageCountMode)
            {
                return string.Format(CultureInfo.CurrentCulture, "{0}{1}", pageCount, pageCountMode == PageCountMode.Estimate ? "~" : String.Empty);
            }
    
            #endregion
        }
    }

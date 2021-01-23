    public class Checkboxes {
        public bool IsAtLeastOneSelected
        {
            get{
                return PaginasConsultadas.Any(r => r.ValorCheckBox == [WHATEVER_VALUE MEANS_CHECKED]);
            }
        }
    }

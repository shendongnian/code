    public class Checkboxes {
        public bool IsAtLeastOneSelected
        {
            get{
                return PaginasConsultadas.Any(r => r.IsChecked);
            }
        }
    }

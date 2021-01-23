    public class ViewModel
    {
        public List<Data> Items { get; set; }
        public Data SelectedItem { get; set; }
        public ViewModel()
        {
            //Sample Data
            Items = Enumerable.Range(0, 100).Select(x => new Data
                {
                    Product = "Product" + x.ToString(),
                    Details = Enumerable.Range(0, 3)
                                        .Select(d => "Detail" + x.ToString() + "-" + d.ToString())
                                        .ToList()
                }).ToList();
            SelectedItem = Items.First();
        }
    }

    public void mostrar(ListBox medicinas_visual)
    {
        List<Data> objList = new List<Data>();
        var query = from Medicamento in usuario_data.Current.Medicamento
                    orderby Medicamento.id_med
                    select Medicamento;
        foreach (var item in query)
        {
            objList.Add(new Data(item.id_med, item.nombre));
        }
        medicinas_visual.ItemsSource = objList;
    }
    public class Data
    {
        public int id { get; set; }
        public string data { get; set; }
    
        public Data(){ }
        public Data(int id, string data)
        {
            this.id = id;
            this.data = data;
        }
    }

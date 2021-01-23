    public class YourClass
    {
        private List<string> listaAnexos = new List<string>();
        private void YourMethod()
        {
            Archivo.Multiselect = true;
            Archivo.ShowDialog();
            ...
            foreach (string i in anexos) 
            { 
                listaAnexos.Add(i);
                ...

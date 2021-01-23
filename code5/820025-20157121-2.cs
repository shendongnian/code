    class Program
    {
        static void Main(string[] args)
        {
            string json = "{\"Form\": \"2\"}";
            FormParameters fp = JsonConvert.DeserializeObject<FormParameters>(json);
            Console.WriteLine("Form Id = " + fp.Form.Id);
        }
    }

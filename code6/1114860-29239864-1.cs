    public class InvoiceDto
    {
        public string Description { get; set; }
        public int Hours { get; set; }
        public decimal Amount { get; set; }
    }
    public void List<InvoiceDto> GetInvoiceData(int invoiceNumber)
    {
        List<InvoiceDto> data = new List<InvoiceData>();
        using (SqlConnection cs = new SqlConnection("Data Source=JAMES-DESKTOP\\SQLEXPRESS;Initial Catalog=contacts;Integrated Security=True"))
        using (SqlCommand cmd = new SqlCommand("dbo.LookupInvoices", cs))
        {
            cmd.CommandType = CommandType.StoredProcedure;
    
            cmd.Parameters.Add("@invoiceNumber", SqlDbType.Int).Value = invoiceNumber;
    
            cs.Open();
    
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    InvoiceDto dto = new InvoiceDto();
                    dto.Description = reader.GetFieldValue<string>(0);
                    dto.Hours = reader.GetFieldValue<int>(1);
                    dto.Amount = reader.GetFieldValue<decimal>(2);
                    data.Add(dto);
                }
            }
     
            cs.Close();
        }
        return data;
    }

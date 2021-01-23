    public Form1()
    {
        InitializeComponent();
    }
    
    public void LoadData()
    {
    
        CBR.ru.DailyInfoSoapClient rublesClient = new DailyInfoSoapClient();
        DateTime lastRUB = rublesClient.GetLatestDateTime();
        // MessageBox.Show(lastRUB.ToShortDateString());
        var RubRateXml = rublesClient.GetCursOnDateXML(lastRUB);
        DataSet RUBrate = rublesClient.GetCursOnDate(lastRUB);
        string xml = RUBrate.GetXml();
        ValuteDataValuteCursOnDate rates;
        using (StringReader sr = new StringReader(xml))
        {
            XmlSerializer xs = new XmlSerializer(typeof (ValuteDataValuteCursOnDate));
            rates = (ValuteDataValuteCursOnDate) xs.Deserialize(sr);
        }
        richTextBox1.Text = xml;
        // MessageBox.Show(rates.Vname);
    }
    
    var form = new Form1();
    try
    {
        form.LoadData();
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.ToString());
        throw;
    }

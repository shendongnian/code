        private static string ns = "{http://www.website.co.za/namespace}";
        private static string getName(XElement x) {
            if (x == null)
                throw new InvalidOperationException("First elements has no Name");
            var val = (string) x.Element(ns + "Name");
            return val ?? getName((XElement)x.PreviousNode);
        }
        static void Main(string[] args)
        {
            string xml = @"<ScrpHld xmlns=""http://www.website.co.za/namespace"">
            <Scrp>
                <Name>Company Name Number 1</Name>
                <SecCde>1366J</SecCde>
                <Tran>SOLD</Tran>
                <OpBal>0</OpBal>
                <Move>-2000</Move>
            </Scrp>
            <Scrp>
                <Tran>ELECTRONIC SETTLEMENT</Tran>
                <Move>2000</Move>
                <ClPrce>25045.00</ClPrce>
                <ClBal>0</ClBal>
            </Scrp>
            <Scrp>
                <Name>Company Name Number 2</Name>
                <SecCde>1313J</SecCde>
                <Tran>SOLD</Tran>
                <OpBal>10000</OpBal>
                <Move>-90500</Move>
            </Scrp>
            <Scrp>
                <Tran>ELECTRONIC SETTLEMENT</Tran>
                <Move>80500</Move>
                <ClPrce>3392.00</ClPrce>
                <ClBal>0</ClBal>
            </Scrp> 
            </ScrpHld>";
            XDocument doc = XDocument.Parse(xml);
            var result = doc.Descendants(ns + "Scrp").Select(x => new
                {
                    Name = getName(x)
                });
            foreach (var item in result)
            {
                Console.WriteLine(item.Name);
            }

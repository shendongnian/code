        private static void Main(string[] args)
        {
            var data = @"<?xml version=""1.0"" encoding=""utf-8""?>
                        <Instances>
                            <InstanceInfos Name=""i-82c61ac1"">
                                <MaxTime>38</MaxTime>
                            </InstanceInfos>
                            <InstanceInfos Name=""i-83c61ac0"">
                                <MaxTime>447</MaxTime>
                           </InstanceInfos>
                        </Instances>";
            var document = XDocument.Parse(data);
            const string attributeId = "i-82c61ac1";
            var element = document.Descendants("InstanceInfos").FirstOrDefault(p => p.Attribute("Name").Value.Equals(attributeId));
            if (element != null)
            {
                var maxTime = element.Elements("MaxTime").FirstOrDefault();
                if (maxTime != null) maxTime.Value = "100";
            }
            document.Save("FinalResult.xml");
        }

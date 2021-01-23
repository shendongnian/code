        [System.Web.Http.HttpPost]
        public HttpResponseMessage GetMyData()
        {
            var myList = GetTransportTable(); //returns List<TransportInfo>
            var rowlist = new List<Row>() { };
               
            for (var i = 0; i < myList.Count; i++)
            {
                Row rowobj = new Row();
                var stringList = new List<string>();
                rowobj.id = i;
                stringList.Add(myList[i].DockDate.ToString("d"));
                stringList.Add(myList[i].Pilot);
                stringList.Add(myList[i].Vessel);
                stringList.Add(myList[i].Dock);
                stringList.Add(myList[i].Amount.ToString("c"));
                rowobj.cell = stringList;
                rowlist.Add(rowobj);
            }
            var jsonToReturn = new
            {
                total = 1,
                page = 1,
                records = myList.Count.ToString(),
                rows = rowlist
            };
            return Request.CreateResponse(HttpStatusCode.OK, jsonToReturn);
        }

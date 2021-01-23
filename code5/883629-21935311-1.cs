            if (!IsPostBack)
            {
                ParentModel prmodel = new ParentModel();
                prmodel.id = 5;
                List<ProgramModel> listdata = new List<ProgramModel>();
                ProgramModel data = new ProgramModel();
                
                data.id = 7;
                data.parent = prmodel;
                data.name = "program";
                listdata.Add(data);
                var jsdata = from program in listdata select program.ToJSON();
                
            }
        }

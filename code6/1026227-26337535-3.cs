            HeadViewModel headViewModel = new HeadViewModel
            {
                Table1 = new Table1
                {
                    column1 = 0, // you data from the DB table object
                    column2 = ""// you data from the DB table object
                },
                Table2 = new Table2
                {
                    column1 = 0, // you data from the DB table object
                    column2 = ""// you data from the DB table object
                },
                Table3 = new Table3
                {
                    column1 = 0, // you data from the DB table object
                    column2 = ""// you data from the DB table object
                }
            };
            return View(headViewModel);

    private void BindGrid()
            {
                List<Test> testDate = new List<Test>
                {
                    new Test { AValue = 1, BValue = 2 },
                    new Test { AValue = 2, BValue = 4 },
                    new Test { AValue = 3, BValue = 6 }
                };
                grdTest.DataSource = testDate;
                grdTest.DataBind();
            }

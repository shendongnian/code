            TableHelper ProgramOptionsList;
            ProgramOptionsList.mOptionsID = 1234; // Accessing a public/get;set; variable in TableHelper Class
            ProgramOptionsList.Text = "Table Title";
            ProgramOptionsList.ShowDialog();
            ProgramOptionsList.BringToFront(); // Just in case you have multiple tables over lapping each other in TableHelper

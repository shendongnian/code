    public subjectSubReport(List<subject> subjects)
        {           
            InitializeComponent();
    		
                if (subjects.Count > 0){
    
                var apiOutput = new{
    			
                    invoceRpt = subjects.Select(a => new{
                       subjects = a.subjectName,                       
                    })
                };
                    this.DataSource = apiOutput.invoceRpt;                   
                }
       }

         public ordermeal() 
         {
            InitializeComponent();
            yourMealtypeCombobox();
         }
           public void yourMealtypeCombobox()
            {
                DataTable dt = md.GetALLMealTypes(); // 
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "typename";
                comboBox1.ValueMember = "mealtypeid";
            }
    
        
        public void yourMealCombo(int mealtypeid)
                {
                    DataTable dt = md.GetMeals(mealtypeid); // Get your corresponding meal by mealtypeid of Selected mealtype by users
    /* i am assuming your GetMeals() method is able to except input parameter and filter records from input parameter */
                    comboBox2.DataSource = dt;
                    comboBox2.DisplayMember = "Mealname";
                    comboBox2.ValueMember = "unitprice";
         
                }

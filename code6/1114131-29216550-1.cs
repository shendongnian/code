    class StudentEditViewModel
    {
        private Student mStudentModel;
    
        public StudentEditViewModel(Student s)
        {
    	   mStudentModel = s;
        }
    
        [Display(Name = "First name")]
        [Required(ErrorMessage = "First name is required")]
        public string firstname 
    	{
    	    get
    	    {
    			return mStudentModel.fname;
    		}
    		set
    		{
    		    // Check if changed
    			if(mStudentModel.fname != value)
    			{
    			   mStudentModel.fname = value;
    		       // NotifyPropertyChange
    			}
    		}
    	}
    	// same for other properties
    }

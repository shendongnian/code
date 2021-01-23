    public static class Students
    {
    
        public static class FirstGrade {
            public static MyClass John = new MyClass { Id = 1, Message = "Some Text" };
        }
    
        public static class SecondGrade {
            public static MyClass John = new MyClass { Id = 2, Message = "Some Text" };
        }
    
    	public static Type FindStudent(MyClass s, out String varName) {
    		varName = null;
    		foreach (var ty in typeof(Students).GetNestedTypes()) {
    			var arr = ty.GetFields(BindingFlags.Static | BindingFlags.Public);
    			foreach (var fi in arr) {
    				if (fi.FieldType == typeof(MyClass)) {
    					Object o = fi.GetValue(null);
    					if (o == s) {
    						varName = fi.Name;
    						return ty;
    					}
    				}
    			}
    		}
    		return null;
    	}
    
    	public static void FindJohn() {
    		String varName = null;
    		Type ty = FindStudent(SecondGrade.John, out varName);
    		MessageBox.Show(ty == null ? "Not found." : ty.FullName + " " + varName);
    	}
    }

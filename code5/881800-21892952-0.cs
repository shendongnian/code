    public static class ViewModelLocator
    {
        private static Employee myEmployee = null;
        public static Employee GetEmployee()
        {
            if (myEmployee == null)
                myEmployee = new Employee();
            return myEmployee;
        }
    }

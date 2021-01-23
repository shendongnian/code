        public static void DataBaseDisplay(List<Employee> employeeList)
        {
            foreach (Employee employee in employeeList)
            {
                Console.Write(employee.ID + " - " + employee.Name + " - ");
                foreach (var eventId in employee.EventIDs)
                {
                    Console.Write(" " + Events.EventNames[eventId]);
                }
                Console.WriteLine();
            }
        }

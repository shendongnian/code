    public class StudentModel
    {
        //notice the 'async' keyword and generic 'Task(T)' return type
        public async Task<IEnumerable<StudentModel>> GetStudentsAsync(IEnumerable<int> keyList)
        {
            /*to invoke async methods, precede its invocation with
              the 'await' keyword. This allows program flow to return
              the line on which the GetStudentsAsync method was called.
              The flow will return to GetStudentsAsync once the database
              operation is complete.*/
              IEnumerable<StudentModel> students = await FakeDatabaseService.ExecuteSomething();
              return students;
        }
    }
    

    class SubjectFactory
    {
        public IEnumerable<Subject> Read(string filePath)
        {
            string[] subjectStrings = File.ReadAllLines(filePath);
            return Parse(subjectStrings);
        }
        private IEnumerable<Subject> Parse(IEnumerable<string> subjects)
        {
            string code = "XYZ";
            foreach ( var subject in subjects )
            {
                yield return new Subject(code, subject);
            }
        }
    }

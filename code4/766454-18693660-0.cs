    public void AddSubjectDeatils(string SubjectId, double Marks, double NegativeMark,List<Subject> listofsubjects)
        {
           
            var temp = listofsubjects.SingleorDefault(l => l.m_SubjectId == SubjectId);
            if (temp != null)
            {
                temp.m_Marks += Marks;
                temp.m_NegativeMarks += NegativeMark;
                temp.m_TotalMarks += Marks;
            }
            else
            {
                m_SubjectId = SubjectId;
                m_Marks = Marks;
                m_NegativeMarks = NegativeMark;
                m_TotalMarks = Marks;
            }
        }

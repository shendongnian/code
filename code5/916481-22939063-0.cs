    public class Event
    {
            public int StudentID {get; set;}
            public IEnumerable<SelectListItem> DropDownStudent { get; set; }
            public void GetStudents()
            {
                var list = studentcontext.Select(e => new { Value = (int)e.ID, Text = e.Name.ToString() }).ToList();
                DropDownStudent = new SelectList(list, "Value", "Text");
            }
    }

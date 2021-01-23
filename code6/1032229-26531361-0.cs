    public ListCoursesResponse ListCourses(int? categoryId = null)
    {
        Dictionary<String, Object> dico = null;
        
        if (categoryId != null)
        {
            List<KeyValuePair<String, Object>> list = new List<KeyValuePair<string, object>>();
            list.Add(new KeyValuePair<String, Object>("category", categoryId));
            dico = Execute<Dictionary<String, Object>>(String.Format("{0}/{1}", _course, "listCourses"), list.ToArray());
        }
    
        dico = Execute<Dictionary<String, Object>>(String.Format("{0}/{1}", _course, "listCourses"));
    
        return dicoToResponse(dico);
    }

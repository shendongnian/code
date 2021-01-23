    var f = FormManager.Show<Form2>(); //create a new form.
    f = FormManager.Show<Form2>(); //show the existing form.
    f.Close();
    f = FormManager.Show<Form2>(); //create a new form
---
    public static class FormManager
    {
        static Dictionary<Type, Form> _Forms = new Dictionary<Type, Form>();
        public static Form Show<T>() where T: Form, new()
        {
            var type = typeof(T);
            Form f = null;
            if(_Forms.TryGetValue(type,out f))
            {
                f.BringToFront();
            }
            else
            {
                f = new T();
                f.FormClosing += (s, e) => _Forms.Remove(s.GetType());
                _Forms.Add(type, f);
                f.Show();
            }
            return f;
        }
    }

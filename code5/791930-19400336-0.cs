    namespace StackOverflow
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SubjectInfo.SetStr(button1,() => button1,()=> button1.Text);
        }
    }
    class SubjectInfo
    {
        public static void SetStr<T,U>(object obj,Expression<Func<T>> objLambda,     Expression<Func<U>> fieldLambda)
        {
            // get the name of the field
            string fieldName = ((MemberExpression) fieldLambda.Body).Member.Name;
            // get the full name of the whole object and field as it is typed in the source code
            string full_name_in_source = ((MemberExpression)objLambda.Body).Member.DeclaringType + "." + ((MemberExpression)objLambda.Body).Member.Name + "." + fieldName;
            
            obj.GetType().GetProperty(fieldName).SetValue(obj,full_name_in_source);
        }
    }
}

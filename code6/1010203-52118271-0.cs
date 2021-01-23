    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace WindowsFormsApp2
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private List<Student> students = new List<Student>()
        {
            new Student(){ name="Jimmy" },
            new Student(){ name="Billy" },
            new Student(){ name="Sarah" },
            new Student(){ name="Bobby" },
            new Student(){ name="Garry" },
            new Student(){ name="Eva" },
            new Student(){ name="Nancy" }
        };
        private Student _student;
        private class Student
        {
            public string name { get; set; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MoveUpDn(true);
        }
        private void MoveUpDn(bool blnUp)
        {
            if (_student == null) return;
            int idx = students.IndexOf(_student);
            if (blnUp)
            {
                if (idx <= 0) return;
                students.Insert(idx - 1, _student);
                students.RemoveAt(idx + 1);
                idx--;
            }
            else
            {
                if (idx >= students.Count - 1) return;
                students.Insert(idx + 2, _student);
                students.RemoveAt(idx);
                idx++;
            }
            UpdateMyList();
            this.listBox1.SelectedIndex = idx;
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            UpdateMyList();
        }
        private void UpdateMyList()
        {
            this.listBox1.DataSource = null;
            this.listBox1.DataSource = students;
            this.listBox1.DisplayMember = "name";
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;
            if (listBox1.SelectedItem.GetType() != typeof(Student)) return;
            Student student = this.listBox1.SelectedItem as Student;
            if (student == null) return;
            _student = student;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MoveUpDn(false);
        }
    }
    }

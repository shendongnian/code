    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using jsonorm;
    namespace ObjectDAL
    {
    public class Comment
    {
        public string task_comment_id { get; set; }
        public string f_id { get; set; }
        public string comment { get; set; }
        public string created_date { get; set; }
        public string updated_date { get; set; }
    }
    public class Follower
    {
        public string f_id { get; set; }
    }
    public class Task_details : LocalStorage<Task_details>
    {
        public string task_id { get; set; }
        public string created_f_id { get; set; }
        public string task_description { get; set; }
        public string due_date { get; set; }
        public string alert { get; set; }
        public string status { get; set; }
        public string postedon { get; set; }
        public string updatedon { get; set; }
        public List<Comment> comments { get; set; }
        public List<Follower> followers { get; set; }
    }
    public class TaskDetailList : LocalStorage<TaskDetailList>
    {
        public int status { get; set; }
        public string message { get; set; }
        public List<Task_details> Task_details { get; set; }
    }
}

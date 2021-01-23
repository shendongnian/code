    class BaseModel {
        //TO ensure all your models have and id
        [SQLite.PrimaryKey]
        public int Id { get; set; }
    }

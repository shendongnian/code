    using UnityEngine;
    using System;
    using System.Collections;
    using System.Data;
    using Mono.Data.SqliteClient;
    using System.IO;
    
    
    public class dbAccess : MonoBehaviour {
        private string connection;
        private IDbConnection dbcon;
        private IDbCommand dbcmd;
        private IDataReader reader;
    
    public string nama;
    
        void OnGUI()
            {
                GUI.Box(new Rect(150,50,200,200),"Nama");
                nama = GUI.TextField(new Rect(50,30,100,20),nama,25);
                string[] values = {"NULL", nama};
    
                if(GUI.Button(new Rect(65,50,70,20),"Ok"))
                {
                    InsertInto("user", values);
                }
            }
    
        // Use this for initialization
        void Start () {
            if(!PlayerPrefs.GetInt("first_run").Equals(1))
            {
                String _databaseFileName = "mydatabase.sqlite";
                String _databasePath = Application.persistentDataPath + "/" + _databaseFileName;
                StartCoroutine(ExtractFileFromJar(_databaseFileName, _databasePath));
                PlayerPrefs.SetInt("first_run",1);
            }
        }
    
        public static IEnumerator ExtractFileFromJar(string dbName,string writePath)
        {
            WWW loadDb = new WWW("jar:file://" + Application.dataPath + "!/asset/!" + dbName);
            yield return loadDb;
            File.WriteAllBytes(writePath, loadDb.bytes);
        }
    
    
        public void OpenDB(string p)
        {
            connection = "URI=file:mydatabase.sqlite" + p;
            dbcon = new SqliteConnection(connection);
            dbcon.Open();
        }
    
        public void CloseDB()
        {
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbcon.Close();
            dbcon = null;
        }
    
        IDataReader BasicQuery(string query)
        {
            dbcmd = dbcon.CreateCommand();
            dbcmd.CommandText = query;
            reader = dbcmd.ExecuteReader();
            return reader;
        }
    
        int CreateTable(string name, string[] col, string[] colType)
        {
            string query;
            query = "CREATE TABLE" + name + "(" + col[0] + " " + colType[0];
            for(var i=1; i<col.Length; i++){
                query += "," + col[i] + " " + colType[i]; 
            }
            query += ")";
            try{
                dbcmd = dbcon.CreateCommand();
                dbcmd.CommandText = query;
                reader = dbcmd.ExecuteReader();
            }
            catch(Exception e){
                Debug.Log(e);
                return 0;
            }
            return 1;
        }
    
        int InsertIntoSingle(string tableName, string colName, string value)
        {
            string query;
            query = "INSERT INTO" + tableName + "(" + colName + ")" + "VALUES (" + value + ")";
            try{
                dbcmd = dbcon.CreateCommand();
                dbcmd.CommandText = query;
                reader = dbcmd.ExecuteReader();
            }
            catch(Exception e){
                Debug.Log(e);
                return 0;
            }
            return 1;
        }
    
        int InsertIntoSpecific(string tableName, string[] col,string[] values)
        {
            string query;
            query = "INSERT INTO" + tableName + "(" + col[0];
            for(int i=1; i<col.Length; i++){
                query += "," + col[i];
            }
            query += ") VALUES (" + values[0];
            for(int i=1; i<values.Length; i++){
                query += "," + values[i];
            }
            query += ")";
            try{
                dbcmd = dbcon.CreateCommand();
                dbcmd.CommandText = query;
                reader = dbcmd.ExecuteReader();
            }
            catch(Exception e){
                Debug.Log(e);
                return 0;
            }
            return 1;
        }
    
        int InsertInto(string tableName, string[] values, string colName)
        {
            string query;
            query = "INSERT INTO " + tableName + " (" + colName + ") " + "VALUES (" + values[0] + ")";
            for(int i=1; i<values.Length; i++){
                query += ")" + values[i];
            }
            query += ")";
            try{
                dbcmd = dbcon.CreateCommand();
                dbcmd.CommandText = query;
                reader = dbcmd.ExecuteReader();
            }
            catch(Exception e){
                Debug.Log(e);
                return 0;
            }
            return 1;
        }
    
        public string[] SingleSelectWhere(string tableName, string itemToSelect, string wCol, string wPar, string wValue)
        {
            string query;
            query = "SELECT" + itemToSelect + "FROM" + tableName + "WHERE" + wCol + wPar + wValue;
            dbcmd = dbcon.CreateCommand();
            dbcmd.CommandText = query;
            reader = dbcmd.ExecuteReader();
            string[] readArray = new string[reader.RecordsAffected];
            int i=0;
            while(reader.Read()){
                readArray[i] = reader.GetString(0);
                i++;
            }
            return readArray;
        }
    
        void Update () {
    
        }
    }

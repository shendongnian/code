    using UnityEngine;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using JsonFx.Json;
    
    [Serializable]
    [JsonName("Person")]
    public class Person
    {
    	public string name;
    	public string surname;
    }
    
    [JsonName("Animal")]
    public class Animal
    {
    	public string name;
    	public string species;
    }
    
    [Serializable]
    public class Parameters
    {
    	public float floatValue;
    	public string stringValue;
    	public List<Person> listValue;
    }
    
    public class SerializationTest : MonoBehaviour
    {
    	// Use this for initialization
    	void Start()
    	{
    		ScenarioOne();
    	}
    
    	void ScenarioOne()
    	{
    		Dictionary<string, object> parameters = new Dictionary<string, object>();
    		List<Person> persons = new List<Person>();
    		persons.Add(new Person() { name = "Clayton", surname = "Curmi" });
    		persons.Add(new Person() { name = "Karen", surname = "Attard" });
    
    		List<Animal> animals = new List<Animal>();
    		animals.Add(new Animal() { name = "Chimpanzee", species = "Pan troglodytes" });
    		animals.Add(new Animal() { name = "Cat", species = "Felis catus" });
    
    		parameters.Add("floatValue", 3f);
    		parameters.Add("stringValue", "Parameter string info");
    		parameters.Add("persons", persons.ToArray());
    		parameters.Add("animals", animals.ToArray());
    
    		// ---- SERIALIZATION ----
    
    		JsonWriterSettings writerSettings = new JsonWriterSettings();
    		writerSettings.TypeHintName = "__type";
    
    		StringBuilder json = new StringBuilder();
    		JsonWriter writer = new JsonWriter(json, writerSettings);
    		writer.Write(parameters);
    
    		AVDebug.Log(json.ToString());
    
    		// ---- DESERIALIZATION ----
    
    		JsonReaderSettings readerSettings = new JsonReaderSettings();
    		readerSettings.TypeHintName = "__type";
    
    		JsonReader reader = new JsonReader(json.ToString(), readerSettings);
    
    		parameters = null;
    		parameters = (Dictionary<string, object>)reader.Deserialize();
    
    		foreach (KeyValuePair<string, object> kvp in parameters)
    		{
    			string key = kvp.Key;
    			object val = kvp.Value;
    			AVDebug.Log(val == null);
    			AVDebug.Log(string.Format("Key : {0}, Value : {1}, Type : {2}", key, val, val.GetType()));
    		}
    	}
    }

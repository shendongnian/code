    void Main()
    {
	var schema = JsonSchema.Parse(
	@"{
		'type': 'object',
		'properties': {
			'name': {'type':'string'},
			'hobbies': {'type': 'array'}
		},
		'additionalProperties': false
		}");
	IsValid(JObject.Parse(
	@"{
	    'name': 'James',
	    'hobbies': ['.NET', 'LOLCATS']
	  }"), 
	schema).Dump();
	
	IsValid(JObject.Parse(
	@"{
        'surname': 2,
        'hobbies': ['.NET', 'LOLCATS']
      }"), 
	schema).Dump();
	
	IsValid(JObject.Parse(
	@"{
        'name': 2,
        'hobbies': ['.NET', 'LOLCATS']
      }"), 
	schema).Dump();
    }
    public bool IsValid(JObject obj, JsonSchema schema)
    {
    	return obj.IsValid(schema);
    }

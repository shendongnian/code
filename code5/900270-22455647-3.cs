	public async Task<Person> GetPersonAsync(int id)
	{
	    return await GenericApiRequestAsync<Person>("person.byid", string.Format("&id={0}", id));
	}
	public async Task<IDictionary<string, ObjectType2>> GetObjectType2ListAsync(string name)
	{
	    return await GenericApiRequestAsync<IDictionary<string, ObjectType2>>("show.byname", string.Format("&name={0}", name));
	}

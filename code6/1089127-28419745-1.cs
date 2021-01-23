	using System;
	using System.Reflection;
	using WhateverNamespaceIsNeededForWebApiAndEF;
	public class UserUpdate
	{
	  public String Name {get; set;}
	  public bool? PreferredEmailUpdates {get; set;}
	}
	public class User
	{
	  public int Id {get; set;}
	  public String Name {get; set;}
	  public bool PreferredEmailUpdates {get; set;}
	  public DateTimeOffset CreationDate {get; set;}
	}
	[ResponseType(typeof(void))]
	public IHttpActionResult PutUser(string id, UserUpdate command)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}
		User userToUpdate = db.Users.Where(u => u.id == id).FirstOrDefault();
		if (userToUpdate == null)
		{
			return NotFound();
		}
		// THIS IS THE IMPORTANT CODE
		PropertyInfo[] propInfos = command.GetType().GetProperties(BindingFlags.Public|BindingFlags.Instance);
		foreach(var p in propInfos)
		{
			object value = p.GetValue(command);
			if(value != null)
			{
				userToUpdate.GetType().GetProperty(p.Name).SetValue(userToUpdate, value);
			}
		}
		// END IMPORTANT CODE
		try
		{
			db.SaveChanges();
		}
		catch (DbUpdateException)
		{
			if (UserExists(id))
			{
				return Conflict();
			}
			else
			{
				throw;
			}
		}
		return StatusCode(HttpStatusCode.NoContent);
	}

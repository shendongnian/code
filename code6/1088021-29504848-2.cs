    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class user_mstr
    {
    	public string user_cd;
    }
    
    public class FakeContext
    {
    	public List<user_mstr> user_mstr;
    }
    
    public class Program
    {
    	private static string strUserCD = "foo";
    	
    	private static void FirstUserAsNull()
    	{
    		try
    		{
    			Console.WriteLine("OneUserAsNull");
    			FakeContext ctx = new FakeContext();
    			ctx.user_mstr = new List<user_mstr>() { null, new user_mstr(), new user_mstr() };
    			user_mstr vwUser = ctx.user_mstr.FirstOrDefault(x => x.user_cd == strUserCD);
    		}
    		catch (NullReferenceException e)
    		{
    			Console.WriteLine(e.Message);
    		}
    		catch (ArgumentNullException e)
    		{
    			Console.WriteLine(e.Message);
    			Console.WriteLine();
    		}
    	}
    	
    	private static void UserListAsNull()
    	{
    		try
    		{
    			Console.WriteLine("UserListAsNull");
    			FakeContext ctx = new FakeContext();
    			ctx.user_mstr = null;
    			user_mstr vwUser = ctx.user_mstr.FirstOrDefault(x => x.user_cd == strUserCD);
    		}
    		catch (NullReferenceException e)
    		{
    			Console.WriteLine(e.Message);
    		}
    		catch (ArgumentNullException e)
    		{
    			Console.WriteLine(e.Message);
    			Console.WriteLine();
    		}
    	}
    
    	private static void CtxAsNull()
    	{
    		try
    		{
    			Console.WriteLine("CtxAsNull");
    			FakeContext ctx = null;
    			user_mstr vwUser = ctx.user_mstr.FirstOrDefault(x => x.user_cd == strUserCD);
    		}
    		catch (NullReferenceException e)
    		{
    			Console.WriteLine(e.Message);
    			Console.WriteLine();
    		}
    	}
    
    	public static void Main()
    	{
    		CtxAsNull();
    		UserListAsNull();
    		FirstUserAsNull();
    	}
    }

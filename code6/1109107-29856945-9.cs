    using System;
    using System.Collections.Generic;
    using Core.Models;
    using SQLite.Net;
    using System.Linq;
    using SQLite.Net.Async;
    using System.Threading.Tasks;
    using System.Linq.Expressions;
    namespace Core.Managers
    {
    	public interface IRepository<T> where T : class, new()
    	{
    		Task<List<T>> Get();
    		Task<T> Get(int id);
	    	Task<List<T>> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null);
	    	Task<T> Get(Expression<Func<T, bool>> predicate);
	    	AsyncTableQuery<T> AsQueryable();
		    Task<int> Insert(T entity);
		    Task<int> Update(T entity);
		    Task<int> Delete(T entity);
	    }
	    public class Repostory<T> : IRepository<T> where T : new()
	    {
		    private SQLiteAsyncConnection db;
		    public Repostory(SQLiteAsyncConnection db)
		    {
		    	this.db = db;
		    }
		    public AsyncTableQuery<T> AsQueryable()
		    {
		    	return db.Table<T>();
		    }
		    public async Task<List<T>> Get()
		    {
			    return await db.Table<T>().ToListAsync();
		    }
		    public async Task<List<T>> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null)
		    {
			    var query = db.Table<T>();
			    if (predicate != null)
			    {
			    	query = query.Where(predicate);
			    }
			    if (orderBy != null)
			    {
			    	query = query.OrderBy<TValue>(orderBy);
			    }
			    return await query.ToListAsync();
		    }
		    public async Task<T> Get(int id)
		    {
		    	return await db.FindAsync<T>(id);
		    }
		    public async Task<T> Get(Expression<Func<T, bool>> predicate)
		    {
		    	return await db.FindAsync<T>(predicate);
		    }
		    public async Task<int> Insert(T entity)
		    {
		    	return await db.InsertAsync(entity);
		    }
		    public async Task<int> Update(T entity)
		    {
			    return await db.UpdateAsync(entity);
		    }
		    public async Task<int> Delete(T entity)
		    {
		    	return await db.DeleteAsync(entity);
		    }
	    }
    }

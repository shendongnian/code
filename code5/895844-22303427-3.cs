    using System;
    using System.Linq.Expressions;
    public interface IInterceptable<T>
    {
        IProxy<T> AddInterceptor<T1, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, TResult>, T1, TResult> func);
        IProxy<T> AddInterceptor<T1, T2, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, TResult>, T1, T2, TResult> func);
        IProxy<T> AddInterceptor<T1, T2, T3, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, TResult>, T1, T2, T3, TResult> func);
        IProxy<T> AddInterceptor<T1, T2, T3, T4, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, TResult>, T1, T2, T3, T4, TResult> func);
        IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, TResult>, T1, T2, T3, T4, T5, TResult> func);
        IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, T6, TResult>, T1, T2, T3, T4, T5, T6, TResult> func);
        IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, T6, T7, TResult>, T1, T2, T3, T4, T5, T6, T7, TResult> func);
        IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, TResult> func);
        IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> func);
        IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func);
        IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> func);
        IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> func);
        IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> func);
        IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> func);
        IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> func);
    }

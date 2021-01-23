    var taskParameter = Expression.Parameter(typeof (Task));
    const string stateFlagsFieldName = "m_stateFlags";
    var setter =
        Expression.Lambda<Action<Task>>(
            Expression.Assign(Expression.Field(taskParameter, stateFlagsFieldName),
                Expression.Or(Expression.Field(taskParameter, stateFlagsFieldName),
                    Expression.Constant(TASK_STATE_THREAD_WAS_ABORTED))), taskParameter).Compile();

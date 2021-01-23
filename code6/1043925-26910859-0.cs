    SomeTable stAlias = null;
    session.QueryOver<ProblematicView>()
        .Left.JoinAlias(
            pv => pv.SomeTable,              // Join path
            () => stAlias,                   // alias assignment
            st => st.SomeOtherValue == 123)  // "with" clause
        /* etc. */

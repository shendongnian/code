    public string MontaWallCurso(IList<object> cursos) {
        // use reflection or something that uses reflection itself
        foreach( object curso in cursos ) {
            Type cursoType = curso.GetType();
            cursoType.GetProperty("SomePropertyYouAreSureExists").SetValue( curso, 1 );
            cursoType.GetProperty("SomeMethodYouAreSureExists").Invoke( curso, null );
        }
    }

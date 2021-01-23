    public string MontaWallCurso(IList<dynamic> cursos) {
        // use dynamic properties or something that takes dynamic arguments
        foreach( dynamic curso in cursos ) {
            curso.SomePropertyYouAreSureExists = 1;
            curso.SomeMethodYouAreSureExists();
        }
    }

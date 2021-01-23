    private TypeSyntax ParseTypeCore(
        bool parentIsParameter,
        bool isOrAs,
        bool expectSizes,
        bool isArrayCreation)
    {
        var type = this.ParseUnderlyingType(parentIsParameter);
        if (this.CurrentToken.Kind == SyntaxKind.QuestionToken)
        {
            var resetPoint = this.GetResetPoint();
            try
            {
                var question = this.EatToken();
                // Comment added by me
                // This is where the difference occurs 
                // (as for '&' the IsAnyUnaryExpression() returns true)
                if (isOrAs && (IsTerm() || IsPredefinedType(this.CurrentToken.Kind) || SyntaxFacts.IsAnyUnaryExpression(this.CurrentToken.Kind)))
                {
                    this.Reset(ref resetPoint);
                    Debug.Assert(type != null);
                    return type;
                }
                question = CheckFeatureAvailability(question, MessageID.IDS_FeatureNullable);
                type = syntaxFactory.NullableType(type, question);
            }
            finally
            {
                this.Release(ref resetPoint);
            }
        }
        // Check for pointer types (only if pType is NOT an array type)
        type = this.ParsePointerTypeMods(type);
        // Now check for arrays.
        if (this.IsPossibleRankAndDimensionSpecifier())
        {
            var ranks = this.pool.Allocate<ArrayRankSpecifierSyntax>();
            try
            {
                while (this.IsPossibleRankAndDimensionSpecifier())
                {
                    bool unused;
                    var rank = this.ParseArrayRankSpecifier(isArrayCreation, expectSizes, out unused);
                    ranks.Add(rank);
                    expectSizes = false;
                }
                type = syntaxFactory.ArrayType(type, ranks);
            }
            finally
            {
                this.pool.Free(ranks);
            }
        }
        Debug.Assert(type != null);
        return type;
    }

            public ClassFieldNamePrefixes() :
                base("ClassFieldNamePrefixes", "TutorialRules.TutorialRules",
                    typeof (ClassFieldNamePrefixes).Assembly)
            {
            }
            public override ProblemCollection Check(Member member)
            {
                if (!(member.DeclaringType is ClassNode))
                    return this.Problems;
                Field fld = member as Field;
                if (fld == null)
                    return this.Problems;
                if (fld.IsLiteral)
                {
                ....
                }
                return this.Problems;
            }
        }

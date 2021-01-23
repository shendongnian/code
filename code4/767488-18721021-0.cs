    public class RelationshipPrincipleToContent : Relationship<PayLoad>, IRelationshipAllowingSourceNode<Principles>, IRelationshipAllowingTargetNode<Content>
        {
            string RelationshipName;
    
            public RelationshipPrincipleToContent(string RelationshipName, NodeReference targetNode, PayLoad pl)
                : base(targetNode, pl)
            {
                this.RelationshipName = RelationshipName;
            }
    
            public override string RelationshipTypeKey
            {
                get { return RelationshipName; }
            }
        }
    }

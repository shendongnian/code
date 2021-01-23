    using Neo4jClient;
    using Neo4jClient.Cypher;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Neo4JTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    GraphClient client = new GraphClient(new Uri("http://localhost:7474/db/data"));
                    client.Connect();
    
                    // Create nodes and relationship
                    MyNode node1 = new MyNode() { Name = "Test 1" };
                    MyNode node2 = new MyNode() { Name = "Test 2" };
    
                    NodeReference<MyNode> node1ref = client.Create<MyNode>(node1);
                    NodeReference<MyNode> node2ref = client.Create<MyNode>(node2);
    
                    MyRelationShip rel12 = new MyRelationShip(node2ref);
    
                    var Rel1 = client.CreateRelationship<MyNode, MyRelationShip>(node1ref, rel12);               
    
                    MyNode node3 = new MyNode() { Name = "Test 3" };
                    NodeReference<MyNode> node3ref = client.Create<MyNode>(node3);
    
                    MyRelationShip rel13 = new MyRelationShip(node3ref);
                    var Rel13 = client.CreateRelationship<MyNode, MyRelationShip>(node1ref, rel13);
    
                    var query = client.Cypher.Start(new { n1 = node1ref })
                                            .Match("n1-[:MYRELATIONSHIP]->targetnode")
                                            .Return<MyNode>(targetnode => targetnode.As<MyNode>());
                    var res = query.Results;
    
                    int i = 0;
                    foreach (MyNode n in res)
                    {
                        i++;
                        Console.WriteLine(i + ". Name: '" + n.Name + "'");
                    }
                }
                catch(NeoException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                Console.ReadKey();
            }
    
    
            class MyNode
            {
                private string _name = "";
    
                public string Name
                {
                    get
                    {
                        return _name;
                    }
    
                    set
                    {
                        _name = value;
                    }
                }
            }
            public class MyRelationShip : Relationship, IRelationshipAllowingSourceNode<MyNode>, IRelationshipAllowingTargetNode<MyNode>
            {
                public static readonly string TypeKey = "MYRELATIONSHIP";
    
                public MyRelationShip(NodeReference targetNode)
                    : base(targetNode)
                { }
    
                public override string RelationshipTypeKey
                {
                    get { return TypeKey; }
                }
            }
        }
    }

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;
    namespace XmlTest
    {
        public class BaseMemberType
        {
            public string SomeValue
            {
                get;
                set;
            }
        }
        public abstract class BaseType
        {
            [XmlElement("Member", Type=typeof(BaseMemberType))]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual BaseMemberType _MemberSerializer
            {
                get
                {
                    return Member;
                }
                set
                {
                    this.Member = (BaseMemberType)value;
                }
            }
            [XmlIgnore()]
            public BaseMemberType Member
            {
                get;
                set;
            }
        }
 
        public class DerivedMemberType
        {
            public int SomeValue
            {
                get;
                set;
            }
        }
        public class DerivedType : BaseType
        {
            [XmlIgnore()]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public override BaseMemberType _MemberSerializer
            {
                get
                {
                    return new BaseMemberType()
                    {
                        SomeValue = this.Member.SomeValue.ToString()
                    };
                }
                set
                {
                    this.Member = new DerivedMemberType()
                    {
                        SomeValue = int.Parse(value.SomeValue)
                    };
                }
            }
            [XmlIgnore()]
            public new DerivedMemberType Member
            {
                get;
                set;
            }
        }
        public class AnotherDerivedType : BaseType
        {
        }
        public class RootElement
        {
            public DerivedType First
            {
                get;
                set;
            }
            public AnotherDerivedType Second
            {
                get;
                set;
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(RootElement));
                RootElement rootElement = null;
                string xml = @"
    <RootElement>
    <First>
    <Member><SomeValue>1234</SomeValue></Member>
    </First>
    <Second>
    <Member><SomeValue>Some string</SomeValue></Member>
    </Second>
    </RootElement>
    ";
                using(var reader = new System.IO.StringReader(xml))
                {
                    rootElement = (RootElement)serializer.Deserialize(reader);
                }
                Console.WriteLine("First.Member.SomeValue: {0}", rootElement.First.Member.SomeValue);
                Console.WriteLine("Second.Member.SomeValue: {0}", rootElement.Second.Member.SomeValue);
                using (var writer = new System.IO.StringWriter())
                {
                    serializer.Serialize(writer, rootElement);
                    string serialized = writer.ToString();
                    Console.WriteLine("Deserialized: ");
                    Console.WriteLine(serialized);
                }
            }
        }
    }

	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Runtime.Serialization;
	using System.Xml;
	namespace NS
	{
		/// <summary>This static class handles data serialization for the app.</summary>
		/// <remarks>
		/// <para>The serialization format is Microsoft's .NET binary XML, documented in [MC-NBFX] specification.</para>
		/// <para>The efficiency could be improved further, by providing a pre-built XML dictionary.</para>
		/// </remarks>
		internal static class Serializer
		{
			/// <summary>Serializers are cached here</summary>
			static readonly Dictionary<Type, DataContractSerializer> s_serializers = new Dictionary<Type, DataContractSerializer>();
			/// <summary>Either get the serializer from cache, or create a new one for the type</summary>
			/// <param name="tp"></param>
			/// <returns></returns>
			private static DataContractSerializer getSerializer( Type tp )
			{
				DataContractSerializer res = null;
				if( s_serializers.TryGetValue( tp, out res ) )
					return res;
				lock( s_serializers )
				{
					if( s_serializers.TryGetValue( tp, out res ) )
						return res;
					res = new DataContractSerializer( tp );
					s_serializers.Add( tp, res );
					return res;
				}
			}
			/// <summary>Read deserialized object from the stream.</summary>
			/// <typeparam name="T"></typeparam>
			/// <param name="stm"></param>
			/// <returns></returns>
			public static T readObject<T>( Stream stm ) where T: class
			{
				DataContractSerializer ser = getSerializer( typeof( T ) );
				using( var br = XmlDictionaryReader.CreateBinaryReader( stm, XmlDictionaryReaderQuotas.Max ) )
					return (T)ser.ReadObject( br );
			}
			/// <summary>Write serialized object to the stream.</summary>
			/// <typeparam name="T"></typeparam>
			/// <param name="stm"></param>
			/// <param name="obj"></param>
			public static void writeObject<T>( Stream stm, T obj ) where T: class
			{
				DataContractSerializer ser = getSerializer( typeof( T ) );
				using( XmlDictionaryWriter bw = XmlDictionaryWriter.CreateBinaryWriter( stm, null, null, false ) )
				{
					ser.WriteObject( bw, obj );
					bw.Flush();
				}
				stm.Flush();
			}
		}
	}
